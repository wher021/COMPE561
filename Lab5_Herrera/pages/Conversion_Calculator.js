window.addEventListener("load", start, false);

var input;
var length,feet,meters,miles,volume,ounces,quarts,liters,area,sqfeet,sqmile,acres;
var text1, text2, text3;
var p1, p2, p3;

function start()
{
    p1 = document.getElementById("p1");
    p2 = document.getElementById("p2");
    p3 = document.getElementById("p3");

    input = document.getElementById("Text4");
    text1 = document.getElementById("Text1");
    text2 = document.getElementById("Text2");
    text3 = document.getElementById("Text3");

    length = document.getElementById("Radio1");
    feet = document.getElementById("Radio2");
    meters = document.getElementById("Radio3");
    miles = document.getElementById("Radio4");
    volume = document.getElementById("Radio5");
    ounces = document.getElementById("Radio6");
    quarts = document.getElementById("Radio7");
    liters = document.getElementById("Radio8");
    area = document.getElementById("Radio9");
    sqfeet = document.getElementById("Radio10");
    sqmile = document.getElementById("Radio11");
    acres = document.getElementById("Radio12");
    input.addEventListener("keydown", doOperation);

} // end function start

function doOperation(e) {

    if (e.keyCode != 13)//return if not enter
        return;
    if (length.checked)//Length checked  
    {
        p1.textContent = "feet";
        p2.textContent = "meters";
        p3.textContent = "miles";
        if (feet.checked) { //m = (f / 3.2808), f, mil = (m / 1000 * 0.62137));

            text1.value = input.value;
            text2.value = (text1.value / 3.2808).toFixed(4);
            text3.value = (text2.value / 1000 * 0.62137).toFixed(4);
        }
        else if (meters.checked) {//  double feet = m * 3.28084;
            //double miles = m / 1609.34;
            text2.value = input.value;
            text1.value = (text2.value * 3.28084).toFixed(4);
            text3.value = (text2.value / 1609.34).toFixed(4);
        }
        else if (miles.checked) {// m = (mil * 1609.34), f = (mil * 5280), mil);
            text3.value = input.value;
            text1.value = (text3.value * 5280).toFixed(4);
            text2.value = (text3.value * 1609.34).toFixed(4);
        }
        else {
            alert("illegal combination");
            text1.value = "";
            text2.value = "";
            text3.value = "";
        }
    }
    else if (volume.checked)
    {
        p1.textContent = "ounces";
        p2.textContent = "quarts";
        p3.textContent = "liters";
        if (ounces.checked) { //ounces, quarts = ounces / 32, liters = ounces * 0.0295735);

            text1.value = input.value;
            text2.value = (text1.value / 32).toFixed(4);
            text3.value = (text1.value * 0.0295735).toFixed(4);
        }
        else if (quarts.checked) {//  ounces = quarts * 32, quarts, liters = quarts * 0.946353);

            text2.value = input.value;
            text1.value = (text2.value * 32).toFixed(4);
            text3.value = (text2.value * 0.946353).toFixed(4);
        }
        else if (liters.checked) {// ounces = liters * 33.814, quarts = liters * 1.0669, liters);
            text3.value = input.value;
            text1.value = (text3.value * 33.814).toFixed(4);
            text2.value = (text3.value * 1.0669).toFixed(4);
        }
        else {
            alert("illegal combination");
            text1.value = "";
            text2.value = "";
            text3.value = "";
        }
    }
    else if (area.checked)
    {
        p1.textContent = "sqfeet";
        p2.textContent = "sqmile";
        p3.textContent = "acres";
        if (sqfeet.checked) { //feet, miles = feet / 27878400, acres = feet * 0.00002296);

            text1.value = input.value;
            text2.value = (text1.value / 27878400).toFixed(6);
            text3.value = (text1.value * 0.00002296).toFixed(6);
        }
        else if (sqmile.checked) {//  feet={0},miles={1},acres={2}", miles * 27878400, miles, miles * 640);

            text2.value = input.value;
            text1.value = (text2.value * 27878400).toFixed(4);
            text3.value = (text2.value * 640).toFixed(4);
        }
        else if (acres.checked) {// "feet={0},miles={1},acres={2}", acres * 43560, acres * 0.0015625, acres);
            text3.value = input.value;
            text1.value = (text3.value * 43560).toFixed(4);
            text2.value = (text3.value * 0.0015625).toFixed(4);
        }
        else {
            alert("illegal combination");
            text1.value = "";
            text2.value = "";
            text3.value = "";
        }
    }
    else
        alert("don't forget to choose category!");

}