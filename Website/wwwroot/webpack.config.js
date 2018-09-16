const path = require('path');
var ExtractTextPlugin = require('extract-text-webpack-plugin');


module.exports = {
    entry: {
        server: ['babel-polyfill', './src/js/server.js'],
        client: './src/js/client.js'       
    },
    output: {
        path: path.resolve('dist'),
        filename: '[name].js',
        publicPath: '/dist/'
    },
    externals: {
        jquery: /^(jquery|\$)$/i
    },
    resolve: {
        extensions: ['.js', '.jsx']
    },
    module: {
        rules: [
            {
                test: /\.js$/,
                exclude: /node_modules/,
                use: {
                    loader: "babel-loader"
                }
            },
            {
                test: /\.css/,
                loader: ExtractTextPlugin.extract("css-loader?modules&importLoaders=1&localIdentName=[name]__[local]__[hash:base64:5]")
            }
        ]
    },
    devServer: {
        proxy: {
            '*': {
                target: 'http://localhost:59666',
                changeOrigin: true,
            },
            port: 8080,
            host: '0.0.0.0',
            hot: false
        }
    },
    plugins: [
        new ExtractTextPlugin("styles.css")
    ]
};