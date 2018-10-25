// ES5
!(function() {
  'use strict';

  // var _second = 0;
  // var _id = 0;
  // var _startTimer = function() {
  //   console.log(_second);
  //   _second--;
  //   _id = window.setTimeout(function() {
  //     _second >= 0 ? _startTimer() : _stopTimer(_id);
  //   }, 1000);
  // };
  // var _stopTimer = function() {
  //   window.clearTimeout(_id);
  // };

  // var $timer = {
  //   start: function(n) {
  //     _second = n;
  //     _startTimer();
  //   },
  //   pause: function() {
  //     _stopTimer();
  //   },
  //   restart: function() {
  //     _startTimer();
  //   }
  // };
  // window.$timer = window.$timer || $timer;

  function Timer(second) {
    this.second = second;
    this.id = 0;
  }

  Timer.prototype.start = function() {
    var that = this;
    console.log(this.second);
    this.second--;

    this.id = window.setTimeout(function() {
      that.second >= 0 ? that.start() : that.pause();
    }, 1000);
  };

  Timer.prototype.pause = function() {
    window.clearTimeout(this.id);
  };

  Timer.prototype.restart = function() {
    this.start();
  };

  window.Timer = window.Timer || Timer;
})();
