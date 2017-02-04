var gulp = require('gulp');
var LiveServer = require('gulp-live-server');
var browserSync = require('browser-sync');
var browserify = require('browserify');
var reactify = require('reactify');
var source = require('vinyl-source-stream'); 


gulp.task('live-server', function (){
    var server = new LiveServer('server/main.js');
    server.start();
});

gulp.task('copy', function(){
    gulp.src(['app/*.css'])
    .pipe(gulp.dest('./.tmp'))
})


gulp.task('bundle',['copy'], function (){
   return browserify({
       entries:'app/main.jsx',
       debug: true,  // improve console output

   })
   .transform(reactify) // transform main.jsx into js 
   .bundle() // indicate that everything ready to run
   .pipe(source('app.js'))
   .pipe(gulp.dest('./.tmp')); // move the output to the dir
});

// ['live-server'] - indicate that our task is dependant on this task
gulp.task('serve', ['bundle','live-server'], function (){
    browserSync.init(null, {
        proxy: "http://localhost:7777",
        port: 9001
    });
});