# Beertap

**Office List**

Method: Get

URL: http://localhost:3000//office

**Office**

Method: Get

URL: http://localhost:3000//office(1)

**Beer List**

Method: Get

URL: http://localhost:3000//office(1)/beer

**Beer**

Method: Get

URL: http://localhost:3000//office(1)/beer(1)

**Get Beer**

Method: POST

URL: http://localhost:3000//office(1)/beer(1)

Raw, Json:
```
{
  "Id": 1,
  "OfficeId": 1,
  "Brand": "Budweiser",
  "Milliliters": 4000,
  "BeerState": "New"
}
```

**Replace Keg**

Method: POST

URL: http://localhost:3000//office(1)/ReplaceKeg(1)

Raw, Json:
```
{
  "Id": 1,
  "OfficeId": 1,
  "Brand": "Budweiser",
  "Milliliters": 4000,
  "BeerState": "New"
}
```
