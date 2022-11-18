const { wrap } = require("../../utils/request");
const sql = require("mssql/msnodesqlv8");

module.exports = wrap(async function (req, res) {
  const storeId = req.query.storeId;
  // If the information is missing, return an error
  if (!req.query.requestedStoreId || !req.query.itemId || !req.query.quantity) {
    return res
      .status(400)
      .json({ status: 400, message: "Invalid request body" });
  }

  // Create an SQL connection
  const pool = new sql.ConnectionPool(require("../../sqlConfig.json"));
  await pool.connect();
  const request = new sql.Request(pool);

  // Insert a transfer request
  const query = `INSERT INTO Transfers(OrderDateTime, RequestingStoreId, RequestedStoreId, ItemId, Quantity, TransferStatus, CompletedDateTime)
                 VALUES (GETDATE(), ${storeId}, ${req.query.requestedStoreId}, ${req.query.itemId}, ${req.query.quantity}, 0, NULL)`;
  const result = await request.query(query);
  pool.close();

  // Return the result
  return res.status(200).json({ status: 200, data: result });
});
