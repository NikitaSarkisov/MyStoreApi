# MyStoreApi

Simple REST API representing an online store.

Items are static and are created at startup. Orders can be Created, Updated and Deleted.

## Project

The project is written in C# using .NET 5 with ASP.NET Core 5.

Database: Entity Framework Core with In Memory Database.

Docker:

```bash
docker run -d -e ASPNETCORE_URLS=http://+:80 -p 80:80 nikitasarkisov/mystoreapi
```

## Entities

`Item`

```json
{
    "id": { int },
    "name": { string },
    "price": { long }
}
```

`Order`

```json
{
    "id": { int },
    "created": { DateTime },
    "modified": { DateTime? },
    "items": [ { Item } ]
}
```

## API Functions

`insomnia_template.json` can be imported into Insomnia to test API.

### List All Items

Lists all items in the store as a json array.

`Request`

```
GET /api/orders
```

`Response`

```
200 OK

[
  {
    "id": 1,
    "name": "Apple iPhone",
    "price": 50000
  },
  {
    "id": 2,
    "name": "Google Pixel",
    "price": 40000
  },
  {
    "id": 3,
    "name": "Nokia 4.2",
    "price": 15000
  },
  {
    "id": 4,
    "name": "Samsung Galaxy",
    "price": 70000
  }
]
```

### Get all orders

Lists all orders in the store as a json array.

`Request`

```
GET /api/orders
```

`Response`

```
200 OK

[
  {
    "id": 1,
    "created": "2021-06-12T18:48:34.06204+00:00",
    "modified": null,
    "items": ...
  }
]
```

### Get order by id

Gets order by specified Id. Id must be int.

`Request`

```
GET /api/orders/{id}
```

`Response`

```
200 OK

{
  "id": 1,
  "created": "2021-06-12T18:48:34.06204+00:00",
  "modified": null,
  "items": ...
}
```

If Id does not exists:
```
404 Not Found
```

### Create order

Create an order with specified items. ItemsIds must be a int array.

`Request`

```
POST /api/orders

{
    "itemsIds": [ { int } ]
}
```

`Response`

```
200 OK

location: http://localhost/api/orders/2

{
  "id": 2,
  "created": "2021-06-12T18:54:16.8959308+00:00",
  "modified": null,
  "items": ...
}
```

If any of Item ids does not exist or ItemsIds is empty:

```
400 Bad Request
```

### Update order

Update order with specified id. ItemsIds must be a int array.

`Request`

```
PUT /api/orders/{id}

{
    "itemsIds": [ { int } ]
}
```

`Response`

```
200 OK

location: http://localhost/api/orders/1

{
  "id": 1,
  "created": "2021-06-12T18:48:34.06204+00:00",
  "modified": "2021-06-12T18:59:41.8653591+00:00",
  "items": ...
}
```

If any of Item ids does not exist or ItemsIds is empty:

```
400 Bad Request
```

If Id does not exist:

```
404 Not Found
```

### Delete order

Deletes order with specified id.

`Request`

```
DELETE /api/orders/{id}
```

`Response`

```
200 OK
```

If Id does not exist:

```
404 Not Found
```
