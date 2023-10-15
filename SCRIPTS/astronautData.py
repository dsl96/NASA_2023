#!/usr/bin/env python
# coding: utf-8

# In[7]:


url_template = 'https://ll.thespacedevs.com/2.2.0/astronaut/?limit={}&offset={}'


# In[8]:


import requests


# In[ ]:





# In[9]:


offset = 0
limit = 100
print(offset)
responses = []
while True:
 
    url = url_template.format(limit,offset)
    print(url)

    response = requests.get(url)

    if response.status_code == 200:
        json_data = response.json()

        if len(json_data['results'])==0:
            break
            
        responses.append(json_data)
    
    else:
        print(f"Error: Unable to fetch data. Status code: {response.status_code}")
        break

    offset = offset+ 100


# In[10]:


all_result = []  

for res in responses:
        all_result.extend(res['results'] )


print('result count:',len(all_result))


# In[39]:


all_egancies_set = set()
 

for result in all_result:
    if(result['agency']):
      all_egancies_set.add(tuple(result['agency'].items()))
   

all_egancies = [dict(e) for e in all_egancies_set]

#print('egentcies', len(all_egancies))    
#for k ,v in all_egancies[0].items():
 #   print(f'{k}  {v}')


# In[79]:


all_result[0]['agency']


# ### SQL

# In[3]:


import pyodbc


# In[106]:


# Define the connection string with trusted connection
conn_str = (
    r'DRIVER={SQL Server Native Client 11.0};'
    r'SERVER=(localdb)\Space2023;'
    r'DATABASE=space2023Db;'
    r'Trusted_Connection=yes;'
)

 


# In[ ]:





# In[107]:


conn = pyodbc.connect(conn_str)
cursor = conn.cursor()


# In[108]:


table_name = '[space2023Db].[dbo].[Astronauts]'
sql = f"DELETE FROM {table_name}"
cursor.execute(sql)
conn.commit()


# In[109]:


table_name = ' [space2023Db].[dbo].[Agency]'
sql = f"DELETE FROM {table_name}"
cursor.execute(sql)
conn.commit()


# In[110]:


all_egancies_values_tuple_sqlOrder = [
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
   )
   for data in all_egancies
]


# In[ ]:





# In[111]:


cursor.executemany('''
    INSERT INTO [space2023Db].[dbo].[Agency]
    ([id], [url], [name], [featured], [type], [country_code], [abbrev], [description], [administrator], [founding_year], [launchers], [spacecraft], [logo_url])
    VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
''', all_egancies_values_tuple_sqlOrder)

conn.commit()


# In[ ]:





# In[112]:


astronaut_data_to_insert = [
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
    for data in all_result
]
 


# In[113]:


cursor.executemany("""
    INSERT INTO Astronauts (
        id, url, name, status_stausId, in_space, time_in_space, eva_time, age, date_of_birth, date_of_death, 
        nationality, bio, twitter, instagram, wiki, agencyid, profile_image, profile_image_thumbnail, flights_count, 
        landings_count, spacewalks_count, last_flight, first_flight, status_Name
    )
    VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
""", astronaut_data_to_insert)

# Commit the transaction
conn.commit()


# In[114]:


cursor.close()
conn.close()


# In[ ]:




