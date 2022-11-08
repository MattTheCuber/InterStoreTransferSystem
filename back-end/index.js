const express = require("express");
const Auth = require("./utils/auth");

const LoginRoute = require("./routes/v1/login");
const RequestsRoute = require("./routes/v1/requests");
const ItemsRoute = require("./routes/v1/items");
const StoreItemsRoute = require("./routes/v1/storeItems");
const CreateRequestRoute = require("./routes/v1/createRequest");

const app = express();
app.use(Auth);
app.use(require("cors")());
app.use(express.json());

app.get("/v1/login", LoginRoute);
app.get("/v1/items", ItemsRoute);
app.get("/v1/items/:itemId", StoreItemsRoute);
app.get("/v1/requests", RequestsRoute);
app.post("/v1/requests/create", CreateRequestRoute);
app.listen(3030, () => console.log("[API] Now listening on port 3030"));

// http://localhost:3030/v1/requests/incoming?storeId=91763&key=bc547750b92797f955b36112cc9bdd5cddf7d0862151d03a167ada8995aa24a9ad24610b36a68bc02da24141ee51670aea13ed6469099a4453f335cb239db5da
