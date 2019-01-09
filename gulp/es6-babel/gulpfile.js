var { task, src, dest } = require('gulp');
var babel = require('gulp-babel');

// Use .babelrc instead
// var options = {
//   presets: ['@babel/preset-env']
// };

function default_task(cb) {
  return src('src/*.js')
    .pipe(babel())
    .pipe(dest('dist'));
}

task('default', default_task);
