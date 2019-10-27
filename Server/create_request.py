import requests
import sys

r = requests.post(sys.argv[1], data=sys.argv[2], headers={"content-type":"application/json"})

print(r.status_code, r.json())
