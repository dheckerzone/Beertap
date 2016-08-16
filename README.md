# Beertap

**Office List**

Method: Get

URL: http://localhost:3000//offices

**Office**

Method: Get

URL: http://localhost:3000//offices(1)

**Beer List**

Method: Get

URL: http://localhost:3000//offices(1)/beers

**Beer**

Method: Get

URL: http://localhost:3000//offices(1)/beers(1)

**Get Beer**

Method: POST

URL: http://localhost:3000//offices(1)/beers(1)

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

URL: http://localhost:3000//offices(1)/ReplaceKeg(1)

Raw, Json:
```
{
  "Id": 1,
  "OfficeId": 1,
  "Brand": "Budweiser",
  "Milliliters": 4000,
  "BeerState": "New"
}

**Add Keg**

Method: POST

URL: http://localhost:3000//offices(1)/AddKeg

Raw, Json:
```
{
  "OfficeId": 1,
  "Brand": "Corona Extra",
  "Milliliters": 4000,
  "BeerState": "New"
}

```
