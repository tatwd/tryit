// load plugins
var gulp        = require('gulp');
var browserSync = require('browser-sync').create(); 

// static server to listen css + html files
gulp.task('serve', function() {
    //place code for your default tast here
    browserSync.init({
        server: {
            baseDir:"./src",   // base directory
            index: "demo.html" // default open the file
        }    
    });

    gulp.watch('src/css/*.css', ['css']);
    gulp.watch('src/js/*.js', ['js']);
    gulp.watch('src/*.html').on('change', browserSync.reload);
});

// listen css files
gulp.task('css', function() {
    return gulp.src('src/css/*.css')
        .pipe(browserSync.reload({  // loads the changed css
            stream: true
        }));
});

// listen js files
gulp.task('js', function(){
    return gulp.src('src/js/*.js')
        .pipe(browserSync.reload({ // loads the changed js
            stream: true
        }));
});

gulp.task('default', ['serve']); // serve then defalut