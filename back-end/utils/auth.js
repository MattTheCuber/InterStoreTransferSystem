const sql = require("mssql/msnodesqlv8");

module.exports = async (req, res, next) => {
  const pool = new sql.ConnectionPool(require("../sqlConfig.json"));
  await pool.connect();
  const request = new sql.Request(pool);
  const query = `SELECT * FROM Stores WHERE StoreId = ${req.query.storeId}`;
  let password;
  try {
    const result = await request.query(query);
    password = result.recordset[0].StorePassword.toLowerCase();
  } catch (err) {
    return res.status(400).json({
      status: 400,
      data: 'Missing or wrong "storeId" query parameter',
    });
  }
  pool.close();

  if (req.query?.key?.toLowerCase() === password) {
    next();
  } else {
    return res.status(400).json({
      status: 400,
      reason: 'Missing or wrong "key" query parameter',
    });
  }
};
