window.addEventListener("load", start, false);

var initial_ivestment;
var monthlyDeposit;
var InterestRate;
var nr_months;
var button;
var output;

function start() {

    button = document.getElementById("Button1");
    initial_ivestment = document.getElementById("Text1");
    monthlyDeposit = document.getElementById("Text2");
    InterestRate = document.getElementById("Text3");
    nr_months = document.getElementById("Text4");
    output = document.getElementById("div1");
    
    button.addEventListener("click", calculateInterest);

    
} // end function start

function calculateInterest() //tr is the row // td is the column
{

    var balance = parseInt(initial_ivestment.value);
    var content = "<table><thead><th>Month</th><th>Amount</th></thead><tbody>";

    for (var i = 0; i < nr_months.value; i++) {
        if (i == 0)
            content += "<tr><td>" + i + "</td><td>" + balance.toFixed(2) + "</td></tr>";
        else {
            balance = parseInt(balance) + balance * InterestRate.value / 1200 + parseInt(monthlyDeposit.value);
            content += "<tr><td>" + i + "</td><td>" + balance.toFixed(2) + "</td></tr>";
        }
    }
    output.innerHTML = content;
}