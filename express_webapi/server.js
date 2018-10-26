var express = require('express');
var bodyParser = require('body-parser');
var mongoose = require('mongoose');

// import models
var Bear = require('./app/models/bear');

// connect mongodb
var db = 'test';
var connection = `mongodb://localhost:27017/${db}`;
mongoose.connect(
  connection,
  function(err) {
    if (err) console.log(err.message);
  }
);

var app = express();

app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());

var port = process.env.PORT || 8080;

// routes for the api
var router = express.Router();

// middleware to use for all requests
router.use(function(req, res, next) {
  // do logging
  console.log('Something is happening.');
  next(); // make sure we go to the next routes and don't stop here
});

router.get('/', function(req, res) {
  res.json({
    message: 'welcome to our api!'
  });
});

router
  .route('/bears')

  // create a bear (accessed at POST http://localhost:8080/api/bears)
  .post(function(req, res) {
    var bear = new Bear();
    bear.name = req.body.name;

    // save the bear and check for errors
    bear.save(function(err) {
      if (err) res.send(err);
      res.json({ message: 'Bear created!' });
    });
  })

  // get all the bears (accessed at GET http://localhost:8080/api/bears)
  .get(function(req, res) {
    Bear.find(function(err, bears) {
      if (err) res.send(err);
      res.json(bears);
    });
  });

router
  .route('/bears/:bear_id')

  // get the bear with that id (accessed at GET http://localhost:8080/api/bears/:bear_id)
  .get(function(req, res) {
    Bear.findById(req.params.bear_id, function(err, bear) {
      if (err) res.send(err);
      res.json(bear);
    });
  })

  // update the bear with this id (accessed at PUT http://localhost:8080/api/bears/:bear_id)
  .put(function(req, res) {
    // use our bear model to find the bear we want
    Bear.findById(req.params.bear_id, function(err, bear) {
      if (err) res.send(err);
      bear.name = req.body.name; // update the bears info

      // save the bear
      bear.save(function(err) {
        if (err) res.send(err);
        res.json({ message: 'Bear updated!' });
      });
    });
  })

  // delete the bear with this id (accessed at DELETE http://localhost:8080/api/bears/:bear_id)
  .delete(function(req, res) {
    Bear.remove(
      {
        _id: req.params.bear_id
      },
      function(err, bear) {
        if (err) res.send(err);
        res.json({ message: 'Successfully deleted' });
      }
    );
  });

// more routes here

// register routes
app.use('/api', router);

// start the server
app.listen(port, function() {
  console.log(`The server is listening on http://localhost:${port}`);
});
