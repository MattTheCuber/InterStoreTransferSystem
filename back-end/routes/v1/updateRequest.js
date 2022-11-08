const { wrap } = require("../../utils/request");

module.exports = wrap(async function (req, res) {
  if (!req.query.transferId || !req.query.status) {
    return res
      .status(400)
      .json({ status: 400, message: "Invalid request body" });
  }

  const pool = new sql.ConnectionPool(require("../../sqlConfig.json"));
  await pool.connect();
  const request = new sql.Request(pool);
  const query = `UPDATE Transfers
                 SET TransferStatus = ${req.query.status}
                 WHERE TransferId = ${req.query.transferId}`;
  const result = await request.query(query);
  pool.close();

  return res.status(200).json({ status: 200, data: result });
});
