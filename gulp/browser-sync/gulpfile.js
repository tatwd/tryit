var { src, watch, series } = require('gulp');
var browserSync = require('browser-sync').create();
var { reload, init } = browserSync;

var SRC_URL = {
  CSS: 'src/css/*.css',
  JS: 'src/js/*.js',
  HTML: 'src/*.html'
};

function css(next) {
  src(SRC_URL.CSS).pipe(
    reload({
      stream: true
    })
  );
  next();
}

function serve(next) {
  // init a server
  init({
    server: {
      baseDir: 'src',
      index: 'demo.html'
    }
  });

  watch(SRC_URL.CSS, css);
  watch(SRC_URL.JS).on('change', reload);
  watch(SRC_URL.HTML).on('change', reload);

  next();
}

exports.default = series(serve);
