const { wrap } = require("../../utils/request");

module.exports = wrap(async function (req, res) {
  // If query parameters are missing, return an error
  if (!req.query.transferId || !req.query.status) {
    return res
      .status(400)
      .json({ status: 400, message: "Invalid request body" });
  }

  // Create an SQL connection
  const pool = new sql.ConnectionPool(require("../../sqlConfig.json"));
  await pool.connect();
  const request = new sql.Request(pool);

  // Update the transfer request
  const query = `UPDATE Transfers
                 SET TransferStatus = ${req.query.status}
                 WHERE TransferId = ${req.query.transferId}`;
  const result = await request.query(query);
  pool.close();

  // Return the result
  return res.status(200).json({ status: 200, data: result });
});
