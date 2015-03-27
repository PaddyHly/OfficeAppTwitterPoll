/// <reference path="../App.js" />

(function () {
    "use strict";

    // The initialize function must be run each time a new page is loaded
    Office.initialize = function (reason) {
        $(document).ready(function () {
            app.initialize();

            $('#addKeyword').click(addKeyword);
            $('#removeKeyword').click(removeKeyword);
        });
    };

    var count = 3;
    var max = 6;
    function addKeyword() {
        if (count <= max) {
            $('#keywords').append('<p style="margin:2px;">Option ' + count + ':  <input type="text" maxlength="20" placeholder="Enter Option" id="key' + count + '" size="25" name="keyword"/ style="border-radius: 3px;"></p>');
            count++;
        }
        if (count > max) {
            $('#addKeyword').attr('disabled','disabled');     
        }
    }

    function removeKeyword() {
        if (count > 3) {
            count--;
            $('#key' + count).parent('p').remove();     
            $('#addKeyword').removeAttr('disabled');   
        }
    }
})();