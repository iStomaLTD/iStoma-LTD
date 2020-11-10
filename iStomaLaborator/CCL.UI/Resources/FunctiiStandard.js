
var lIdControlFocus = null;

function getTextSelectat() {
    if(window.getSelection) { return window.getSelection(); }
        else if(document.getSelection) { return document.getSelection(); }
            else {
                var selection = document.selection && document.selection.createRange();
                if(selection.text) { return selection.text; }
                return null;
            }
    return null;
}

function getSelText() {
    var txt = '';
    if (window.getSelection) {
        txt = window.getSelection();
    }
    else if (document.getSelection) {
        txt = document.getSelection();
    }
    else if (document.selection) {
        txt = document.selection.createRange().text;
    }

    return txt;
}

 function AdaugaSalvareId()
 {
     $("*").focus(function(){
         lIdControlFocus = this.id;
     })
 }

function InsereazaText(TextDeInserat) {
    if(lIdControlFocus != null)
    {
        $("#" + lIdControlFocus).insertAtCaret(TextDeInserat);
    }
    return lIdControlFocus;
}

function ActiveazaControl(pIdElement) {
    if (pIdElement != null) {
        $("#" + pIdElement).focus();
    }
}

function SelecteazaTotTextul() {
    if(lIdControlFocus != null)
    {
        $("#"+lIdControlFocus).select();
    }
}

function GetTextControlSelectat()
{
    return $("#"+lIdControlFocus).text;
}

function SePoateFaceInserarea()
{
    if(lIdControlFocus != null)
    {
        return $("#"+lIdControlFocus).is("textarea");
    }
    return false;
}
        
$.fn.extend({
    insertAtCaret: function(myValue) {
        if (document.selection) {
                this.focus();
                sel = document.selection.createRange();
                sel.text = myValue;
                this.focus();
        }
        else if (this.selectionStart || this.selectionStart == '0') {
            var startPos = this.selectionStart;
            var endPos = this.selectionEnd;
            var scrollTop = this.scrollTop;
            this.value = this.value.substring(0, startPos)+myValue+this.value.substring(endPos,this.value.length);
            this.focus();
            this.selectionStart = startPos + myValue.length;
            this.selectionEnd = startPos + myValue.length;
            this.scrollTop = scrollTop;
        } else {
            this.value += myValue;
            this.focus();
        }
    }
})