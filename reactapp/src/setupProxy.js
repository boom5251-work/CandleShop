const { createProxyMiddleware } = require('http-proxy-middleware');

const context = [
    "/api/*",
    "/api/*/*",
    "/api/*/*/*"
];

module.exports = function (app) {
    const appProxy = createProxyMiddleware(context, {
        target: 'https://localhost:7096',
        secure: false
    });

    app.use(appProxy);
};
