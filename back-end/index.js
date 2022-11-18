// Imports
const express = require("express");
const Auth = require("./utils/auth");

// Import routes
const LoginRoute = require("./routes/v1/login");
const RequestsRoute = require("./routes/v1/requests");
const ItemsRoute = require("./routes/v1/items");
const StoreItemsRoute = require("./routes/v1/storeItems");
const CreateRequestRoute = require("./routes/v1/createRequest");
const UpdateRequestRoute = require("./routes/v1/updateRequest");

// Setup app
const app = express();
app.use(Auth);
app.use(require("cors")());
app.use(express.json());

// Set routes
app.get("/v1/login", LoginRoute);
app.get("/v1/items", ItemsRoute);
app.get("/v1/items/:itemId", StoreItemsRoute);
app.get("/v1/requests", RequestsRoute);
app.get("/v1/requests/create", CreateRequestRoute);
app.get("/v1/requests/update/:status", UpdateRequestRoute);

// Start server
app.listen(3030, () => console.log("[API] Now listening on port 3030"));
