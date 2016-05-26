window.addEventListener("load", start, false);
var arr = [];
var max = document.getElementById('max_text');
var min = document.getElementById('min_text');
var avarage = document.getElementById('avarage_text');
var flag = 0;
function start()
{
    var inp = document.getElementById('num');
    inp.focus();
}

function add(e)
{
    if (e.keyCode != 13)//return if not enter
        return;
    var inp = document.getElementById('num');
    if (inp.value == "q") {
        arr.length = 0;
        alert("empty array");
        inp.value = "";
        min.value = "";
        max.value = "";
        avarage.value = "";
        flag = 1;
        show();
        inp.focus();
        flag = 0;
        return;
    }
    arr.push(inp.value);
    inp.value = '';
    inp.focus();
}

    function show() {
        var html = '';
        var sum = 0;//need to se inital value
        for (var i = 0; i < arr.length; i++)
        {
            html += '<div>' + arr[i] + '</div>';
            sum += parseFloat(arr[i], 10);
        }
        var con = document.getElementById('container');//to output
        con.innerHTML = html;
        if (flag == 0)
        {
            avg(sum,i);
        }
    }
    function avg(sum,i)
    {
        max = document.getElementById('max_text');
        min = document.getElementById('min_text');
        avarage = document.getElementById('avarage_text');

        max.value = Math.max.apply(Math, arr);
        min.value = Math.min.apply(Math, arr);

        avarage.value = (parseFloat(sum) / parseFloat((i))).toFixed(3);
        flag = 0;
    }

    function sort()
    {
        arr.sort(compareIntegers);  // sort the array
        show();
    }

    function compareIntegers( value1, value2 )        
    {                                                 
        return parseInt( value1 ) - parseInt( value2 );
    } // end function compareIntegers    

