module.exports = {
  wrap: function wrap(fn) {
    return function (req, res, next) {
      return fn(req, res, next).catch((err) => {
        next(err);
      });
    };
  },
};
