const path = require('path');

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
                test: /\.css$/,
                use: [
                    {
                        loader: "style-loader"
                    },
                    {
                        loader: "css-loader",
                        options: {
                            modules: true,
                            importLoaders: 1,
                            localIdentName: "[name]_[local]_[hash:base64]",
                            sourceMap: true,
                            minimize: true
                        }
                    }
                ]
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
    plugins: []
};