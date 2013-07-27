ace.define('ace/theme/powershellise', ['require', 'exports', 'module' , 'ace/lib/dom'], function(require, exports, module) {
exports.isDark = false;
exports.cssText = ".ace-powershell-ise .ace_keyword {\
color: #00008B;\
}\
.ace-powershell-ise .ace_identifier {\
color: #8a2be2;\
}\
.ace-powershell-ise .ace_comment {\
color: #008200;\
}\
.ace-powershell-ise .ace_constant.ace_numeric {\
color: #800080;\
}\
.ace-powershell-ise .ace_support.ace_function {\
color: #0000FF;\
}\
.ace-powershell-ise .ace_instance {\
color: #FF4500;\
}\
.ace-powershell-ise {\
background-color: #FFFFFF;\
}\
.ace-powershell-ise .ace_cursor {\
border-left: 2px solid #000000;\
}\
.ace-powershell-ise .ace_overwrite-cursors .ace_cursor {\
border-left: 0px;\
border-bottom: 1px solid #000000;\
}\
.ace-powershell-ise .ace_gutter {\
background: #f0f0f0;\
}\
.ace-powershell-ise .ace_marker-layer .ace_active-line {\
background: #f0f0f0;\
}";

exports.cssClass = "ace-powershell-ise";

var dom = require("../lib/dom");
dom.importCssString(exports.cssText, exports.cssClass);
});