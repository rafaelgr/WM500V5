//=======================================
// WM500V2 (index.js)
// API to communicate to WM500V2 terminals via USB
//========================================
// Author: Rafael Garcia (rafa@myariadna.com)
// 2015 [License CC-BY-4.0]


// required modules
var fs = require('fs');
var express = require('express');
var bodyParser = require('body-parser');

// read app parameters (host and port for the API)
var config = require('.config.json');


// starting express
var app = express();
// to parse body content
app.use(bodyParser);

// mounting routes
var router = express.Router();

// -- common to all routes
router.use(function (req, res, next){
	// go on (by now)
	next();
});

// -- general GET (to know if the server is up and runnig)
router.get('/', function(req,res){
	res.json('WM500V2 API -- runnig');
});


// -- registering routes
app.use('/api',router);
// -- start server
app.listen(config.apiPort);

// -- console message
console.log('WM500V2 API on port: ' + config.apiPort);