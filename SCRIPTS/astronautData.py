import os
import sys
import requests
import pyodbc
from dotenv import load_dotenv
import logging

 
logging.basicConfig(level=logging.INFO, format='%(asctime)s - %(levelname)s: %(message)s')

load_dotenv()
conn_str = os.getenv('DB_CONNECTION_STRING')
logging.info(f"conn string: {conn_str}")

url_template = 'https://ll.thespacedevs.com/2.2.0/astronaut/?limit={}&offset={}'

def fetch_astronaut_data(limit, offset):
    url = url_template.format(limit, offset)
    
    # Log the request URL
    logging.info(f"Fetching data from: {url}")
    
    response = requests.get(url)
    
    if response.status_code == 200:
        logging.info(f"Data fetched successfully from: {url}")
        return response.json()
    else:
        error_message = f"Error: Unable to fetch data from {url}. Status code: {response.status_code} - Reason: {response.reason}"
        logging.error(error_message)
        sys.exit()
        

def insert_agency_data(cursor, all_agencies):
    values = [
        (
           data.get('id'),
           data.get('url'),
           data.get('name'),
           data.get('featured', False),
           data.get('type'),
           data.get('country_code'),
           data.get('abbrev'),
           data.get('description'),
           data.get('administrator'),
           data.get('founding_year'),
           data.get('launchers'),
           data.get('spacecraft'),
           data.get('logo_url')
        ) for data in  all_agencies 
                 ]

    cursor.executemany('''
        INSERT INTO [space2023Db].[dbo].[Agency]
        ([id], [url], [name], [featured], [type], [country_code], [abbrev], [description], [administrator], [founding_year], [launchers], [spacecraft], [logo_url])
        VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
    ''', values)
    logging.info(f"Inserted {len(all_agencies)} records into Agency table.")

def insert_astronaut_data(cursor, all_astronauts):
    values  = [
    (
        data.get('id'),
        data.get('url'),
        data.get('name'),
        data['status'].get('id') if 'status' in data and data['status'] else None,
        data.get('in_space'),
        data.get('time_in_space'),
        data.get('eva_time'),
        data.get('age'),
        data.get('date_of_birth'),
        data.get('date_of_death'),
        data.get('nationality'),
        data.get('bio'),
        data.get('twitter'),
        data.get('instagram'),
        data.get('wiki'),
        data['agency'].get('id') if 'agency' in data and data['agency'] else None ,
        data.get('profile_image'),
        data.get('profile_image_thumbnail'),
        data.get('flights_count'),
        data.get('landings_count'),
        data.get('spacewalks_count'),
        data.get('last_flight'),
        data.get('first_flight'),
        data['status'].get('name') if 'status' in data and data['status'] else None
    )
    for data in all_astronauts ]

    cursor.executemany("""
    INSERT INTO Astronauts (
        id, url, name, status_stausId, in_space, time_in_space, eva_time, age, date_of_birth, date_of_death, 
        nationality, bio, twitter, instagram, wiki, agencyid, profile_image, profile_image_thumbnail, flights_count, 
        landings_count, spacewalks_count, last_flight, first_flight, status_Name
    )
    VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
    """,  values)
    logging.info(f"Inserted {len(all_astronauts)} records into Astronauts table.")


def main():
    try:
        logging.info("Starting script...")

        offset = 0
        limit = 130
        responses = []

        while True:
            json_data = fetch_astronaut_data(limit, offset)

            if not json_data or len(json_data['results']) == 0:
                logging.info("No more data to fetch. Exiting loop.")
                break

            responses.append(json_data)
            offset += limit

        all_result = [data for res in responses for data in res['results']]

        all_agencies_set = set()
        for result in all_result:
            if result['agency']:
                all_agencies_set.add(tuple(result['agency'].items()))
        
        all_agencies = [dict(e) for e in all_agencies_set]

        conn = pyodbc.connect(conn_str)
        cursor = conn.cursor()

        # Clear existing data      
        cursor.execute("DELETE FROM [space2023Db].[dbo].[Astronauts]")
        cursor.execute("DELETE FROM [space2023Db].[dbo].[Agency]")
        conn.commit()
        logging.info("Cleared existing data from Agency and Astronauts tables.")

        insert_agency_data(cursor, all_agencies)
        insert_astronaut_data(cursor, all_result)

        # Commit the transaction and close the connection
        conn.commit()
        cursor.close()
        conn.close()

        logging.info("Data inserted successfully!")

    except Exception as e:
        logging.exception(f"An error occurred: {str(e)}")
        raise

if __name__ == "__main__":
    main()
