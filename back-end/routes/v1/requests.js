const { wrap } = require("../../utils/request");
const sql = require("mssql/msnodesqlv8");

module.exports = wrap(async function (req, res) {
  const storeId = req.query.storeId;

  // If the parameters are missing, return an error
  if (!req.query.type || !["incoming", "outgoing"].includes(req.query.type)) {
    return res.status(400).json({
      status: 400,
      message: 'Missing or wrong "type" query parameter',
    });
  }
  if (!req.query.status || !["active", "history"].includes(req.query.status)) {
    return res.status(400).json({
      status: 400,
      message: 'Missing or wrong "status" query parameter',
    });
  }

  // Initalize query variables
  const idKey =
    req.query.type === "incoming" ? "RequestedStoreId" : "RequestingStoreId";
  const statusKey = req.query.status === "active" ? "IS NULL" : "IS NOT NULL";

  // Create an SQL connection
  const pool = new sql.ConnectionPool(require("../../sqlConfig.json"));
  await pool.connect();
  const request = new sql.Request(pool);

  // Query transfers
  const query = `SELECT *
                 FROM Transfers
                 WHERE ${idKey} = ${storeId}
                       AND CompletedDateTime ${statusKey}`;
  const result = await request.query(query);
  pool.close();

  // Return the result
  return res.status(200).json({ status: 200, data: result.recordset });
});
