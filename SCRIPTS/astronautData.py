#!/usr/bin/env python
# coding: utf-8

import requests
import pyodbc

import os
from dotenv import load_dotenv

# Load environment variables from .env file
load_dotenv()

# Get the connection string from the environment
conn_str = os.getenv('DB_CONNECTION_STRING')

'''
conn_str = (
    r'DRIVER={SQL Server Native Client 11.0};'
    r'SERVER=(localdb)\Space2023;'
    r'DATABASE=space2023Db;'
    r'Trusted_Connection=yes;'
)
'''

# Define the URL template and connection string
url_template = 'https://ll.thespacedevs.com/2.2.0/astronaut/?limit={}&offset={}'


def fetch_astronaut_data(limit, offset):
    url = url_template.format(limit, offset)
    response = requests.get(url)
    
    if response.status_code == 200:
        return response.json()
    else:
        print(f"Error: Unable to fetch data. Status code: {response.status_code}")
        return None

def insert_agency_data(cursor, all_agencies):
    cursor.executemany('''
        INSERT INTO [space2023Db].[dbo].[Agency]
        ([id], [url], [name], [featured], [type], [country_code], [abbrev], [description], [administrator], [founding_year], [launchers], [spacecraft], [logo_url])
        VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
    ''', all_agencies)

def insert_astronaut_data(cursor, all_astronauts):
    cursor.executemany('''
        INSERT INTO Astronauts (
            id, url, name, status_stausId, in_space, time_in_space, eva_time, age, date_of_birth, date_of_death, 
            nationality, bio, twitter, instagram, wiki, agencyid, profile_image, profile_image_thumbnail, flights_count, 
            landings_count, spacewalks_count, last_flight, first_flight, status_Name
        )
        VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
    ''', all_astronauts)

def main():
    offset = 0
    limit = 100
    responses = []

    while True:
        json_data = fetch_astronaut_data(limit, offset)

        if not json_data or len(json_data['results']) == 0:
            break

        responses.append(json_data)
        offset += 100

    all_result = [data for res in responses for data in res['results']]

    all_agencies_set = set()
    for result in all_result:
        if result['agency']:
            all_agencies_set.add(tuple(result['agency'].items()))
    
    all_agencies = [dict(e) for e in all_agencies_set]

    conn = pyodbc.connect(conn_str)
    cursor = conn.cursor()

    # Clear existing data
    cursor.execute("DELETE FROM [space2023Db].[dbo].[Agency]")
    cursor.execute("DELETE FROM [space2023Db].[dbo].[Astronauts]")
    conn.commit()

    insert_agency_data(cursor, all_agencies)

    astronaut_data_to_insert = [
        (
            data.get('id'), data.get('url'), data.get('name'),
            data['status'].get('id') if 'status' in data and data['status'] else None,
            data.get('in_space'), data.get('time_in_space'), data.get('eva_time'), data.get('age'),
            data.get('date_of_birth'), data.get('date_of_death'), data.get('nationality'), data.get('bio'),
            data.get('twitter'), data.get('instagram'), data.get('wiki'),
            data['agency'].get('id') if 'agency' in data and data['agency'] else None,
            data.get('profile_image'), data.get('profile_image_thumbnail'), data.get('flights_count'),
            data.get('landings_count'), data.get('spacewalks_count'), data.get('last_flight'),
            data.get('first_flight'), data['status'].get('name') if 'status' in data and data['status'] else None
        )
        for data in all_result
    ]

    insert_astronaut_data(cursor, astronaut_data_to_insert)

    # Commit the transaction and close the connection
    conn.commit()
    cursor.close()
    conn.close()

if __name__ == "__main__":
    main()
