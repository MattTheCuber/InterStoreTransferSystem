const { wrap } = require("../../utils/request");
const sql = require("mssql/msnodesqlv8");

module.exports = wrap(async function (req, res) {
  // If query parameters are missing, return an error
  if (!req.query.transferId || !req.params.status) {
    return res
      .status(400)
      .json({ status: 400, message: "Invalid request body" });
  }

  // Create an SQL connection
  const pool = new sql.ConnectionPool(require("../../sqlConfig.json"));
  await pool.connect();
  const request = new sql.Request(pool);

  // Initalize the query variable
  const completedDate =
    req.params.status === "3" || req.params.status === "4"
      ? ", CompletedDateTime = GETDATE()"
      : "";

  // Update the transfer request
  const query = `UPDATE Transfers
                 SET TransferStatus = ${req.params.status}${completedDate}
                 WHERE TransferId = ${req.query.transferId}`;
  const result = await request.query(query);
  pool.close();

  // Return the result
  return res.status(200).json({ status: 200, data: result });
});
