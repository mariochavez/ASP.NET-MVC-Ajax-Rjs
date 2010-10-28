/* 
Copyright (c) 2009 Mario Alberto Chavez Cardenas

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/
var RemoteForm = {
    setup: function() {
        $('input.remote').live("click", RemoteForm.formAjax);
    },
    formAjax: function() {
        var formname = '#' + $(this).attr('name');
        var method = $(formname).attr('method');
        var url = $(formname).attr('action');
        var data = $(formname).serialize();

        var currentLink = $(this);

        currentLink.showLoading();

        $.ajax({
            url: url,
            type: method,
            data: data,
            dataType: 'script',
            complete: function(request, settings) {
                currentLink.removeLoading();
            },
            error: function(XMLHttpRequest, textStatus, errorThrown) {
                currentLink.removeLoading();
                alert(textStatus);
            }
        });

        return false;
    }
};

var RemoteLink = {
    setup: function() {
        $('a.remote').live("click", RemoteLink.linkAjax);
    },
    linkAjax: function() {
        var method = "post";

        if ($(this).hasClass('put')) {
            method = "put";
        } else if ($(this).hasClass('delete')) {
            method = "delete";
        } else if ($(this).hasClass('get')) {
            method = "get";
        }

        var url = $(this).attr('href');
        var currentLink = $(this);

        currentLink.showLoading();
        $.ajax({
            url: url,
            type: method,
            dataType: 'script',
            complete: function(request, settings) {
                currentLink.removeLoading();
            },
            error: function(XMLHttpRequest, textStatus, errorThrown) {
                currentLink.removeLoading();
                alert(textStatus);
            }
        });

        return false;
    }
};

var CascadeCombo = {
	setup: function() {
        $('select.cascade').live('change', CascadeCombo.change);
    },
    change: function() {
    	var url = '/' + $(this).attr('rel') + '/' + $(this).attr('name') + 'Change';
    	var data = $(this).val();
    	
    	var currentCombo = $(this);
    	currentCombo.showLoading();
    	$.ajax({
    		url: url,
    		data: { Id: data},
    		type: 'post',
    		dataType: 'script',
    		complete: function(request, settings) {
                currentCombo.removeLoading();
            },
            error: function(XMLHttpRequest, textStatus, errorThrown) {
                currentCombo.removeLoading();
                alert(textStatus);
            }
         });
    }
};

(function($) {
    function Loading() {
        var self = this

        this.html = function() {
            var html = '<span class="ajax-loading">Working ...</span>';
            return html;
        }
    }

    $.fn.removeLoading = function() {
        return this.each(function() {
            $(this).parent().parent().find('.ajax-loading').remove();
        });
    }

    $.fn.showLoading = function() {
        return this.each(function() {
            $(this).removeLoading().parent().after(new Loading().html());
        });
    }
})(jQuery);