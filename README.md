# DEMO Project

Welcome to the DEMO project! This repository contains the source code for a simple API that manages books. Below is the documentation to help you understand and use the API effectively.

## Base URL

The base URL for the API is:
https://your-api-base-url.com/api


## Table of Contents

- [Endpoints](#endpoints)
  - [1. Get Books](#1-get-books)
  - [2. Get Book by ID](#2-get-book-by-id)
  - [3. Add a Book](#3-add-a-book)
  - [4. Update a Book](#4-update-a-book)
  - [5. Delete a Book](#5-delete-a-book)

### 1. Get Books

#### Request

- **Method:** GET
- **Endpoint:** `/Books`
- **Parameters:**
  - `page` (optional): Page number for paginated results (default is 1).
  - `pageSize` (optional): Number of items per page (default is 10).

#### Response

- **Success Code:** 200 OK
- **Content:** List of books based on the specified page and page size.

### 2. Get Book by ID

#### Request

- **Method:** GET
- **Endpoint:** `/Books/{id}`
- **Parameters:**
  - `id`: Identifier of the book.

#### Response

- **Success Code:** 200 OK
- **Content:** Details of the book with the specified ID.
- **Error Code:** 404 Not Found if the book with the given ID does not exist.

### 3. Add a Book

#### Request

- **Method:** POST
- **Endpoint:** `/Books`
- **Body:** JSON payload representing the book to be added.

#### Response

- **Success Code:** 200 OK
- **Content:** Message indicating successful addition ("Saved!").
- **Error Code:** 409 Conflict if a book with the same name already exists.

### 4. Update a Book

#### Request

- **Method:** PUT
- **Endpoint:** `/Books/{id}`
- **Parameters:**
  - `id`: Identifier of the book to be updated.
- **Body:** JSON payload representing the updated book.

#### Response

- **Success Code:** 200 OK
- **Content:** Message indicating successful update ("Updated!").
- **Error Code:** 400 Bad Request if the book ID in the URL does not match the ID in the request body.
- **Error Code:** 404 Not Found if the book with the given ID does not exist.
- **Error Code:** 409 Conflict if a book with the same name already exists.
- **Error Code:** 500 Internal Server Error if an error occurs while updating the book.

### 5. Delete a Book

#### Request

- **Method:** DELETE
- **Endpoint:** `/Books/{id}`
- **Parameters:**
  - `id`: Identifier of the book to be deleted.

#### Response

- **Success Code:** 200 OK
- **Content:** Message indicating successful deletion ("Deleted!").
- **Error Code:** 404 Not Found if the book with the given ID does not exist.


**Note:** Replace placeholder values (e.g., `https://your-api-base-url.com`) with your actual API base URL.

