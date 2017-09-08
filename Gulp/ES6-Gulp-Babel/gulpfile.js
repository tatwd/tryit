const
    gulp = require('gulp'),
    babel = require('gulp-babel'),
    browserify = require('gulp-browserify');

// es6 task
gulp.task('es6', () => {
    return gulp.src('src/js/*.js')
        .pipe(babel({
            presets: ['es2015']
        }))
        .pipe(gulp.dest('dist/js/'));
});

gulp.task('browserify', ['es6'], () => {
    gulp.src('dist/js/test.js')
        .pipe(browserify({
            //
        }))
        .pipe(gulp.dest('dist/'))
})

// default task
gulp.task('default', ['browserify'], () => {
    gulp.watch('src/js/*.js', ['browserify']); // watch js
});