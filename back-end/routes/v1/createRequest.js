const { wrap } = require("../../utils/request");

module.exports = wrap(async function (req, res) {
  const storeId = req.query.storeId;
  // If the information is missing, return an error
  if (!req.body.requestedStoreId || !req.body.itemId || !req.body.quantity) {
    return res
      .status(400)
      .json({ status: 400, message: "Invalid request body" });
  }

  // Create an SQL connection
  const pool = new sql.ConnectionPool(require("../../sqlConfig.json"));
  await pool.connect();
  const request = new sql.Request(pool);

  // Insert a transfer request
  const query = `INSERT Transfers(OrderDateTime, RequestingStoreId, RequestedStoreId, ItemId, Quantity, TransferStatus, CompletedDateTime)
                 VALUES (GETDATE(), ${storeId}, ${req.body.requestedStoreId}, ${req.body.itemId}, ${req.body.quantity}, 0, NULL)`;
  const result = await request.query(query);
  pool.close();

  // Return the result
  return res.status(200).json({ status: 200, data: result });
});
