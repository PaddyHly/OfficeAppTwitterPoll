/// <reference path="../App.js" />

(function () {
    "use strict";

    // The initialize function must be run each time a new page is loaded
    Office.initialize = function (reason) {
        $(document).ready(function () {
            app.initialize();

            $('#get-data-from-selection').click(getDataFromSelection);
            $('#addKeyword').click(addKeyword);
            $('#removeKeyword').click(removeKeyword);
        });
    };

    var count = 3;
    var max = 6;
    function addKeyword() {
        if (count <= max) {
            $('#keywords').append('<p style="margin:4px;">Option ' + count + ':  <input type="text" placeholder="Enter Option" id="key' + count + '" size="25" name="keyword"/ style="border-radius: 3px;"></p>');
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

    // Reads data from current document selection and displays a notification
    function getDataFromSelection() {
        if (Office.context.document.getSelectedDataAsync) {
            Office.context.document.getSelectedDataAsync(Office.CoercionType.Text,
                function (result) {
                    if (result.status === Office.AsyncResultStatus.Succeeded) {
                        app.showNotification('The selected text is:', '"' + result.value + '"');
                    } else {
                        app.showNotification('Error:', result.error.message);
                    }
                }
            );
        } else {
            app.showNotification('Error:', 'Reading selection data is not supported by this host application.');
        }
    }
})();