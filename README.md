
# Authenticating Static Files.

![GitHub repo size](https://img.shields.io/github/repo-size/GuilhermeFM/net6-web-api-static-file-authentication?style=for-the-badge)
![GitHub language count](https://img.shields.io/github/languages/count/GuilhermeFM/net6-web-api-static-file-authentication?style=for-the-badge)

### What i'm trying to do ?

> Well, basically this: Serve static files (like a static html page that was genereted by a automated tool) only to users authenticated through their microsoft account.

### Why do it that way ?

> Static content was generated by an automated tool making it difficult to integrate into the current platform.

### What is in here ?

The project consists of a backend and a frontend:

- The frontend part made in react (because 100% of the current platform is react) is a sketch of a component that authenticates the user with his microsoft account and redirects to the protected address in the backend.
- The backend made with C# and .Net 6 is a web api (which serves the frontend) that implements a middleware that validates the jwt token generated by Miscrosoft and performs the logic of releasing access to the path of static files
