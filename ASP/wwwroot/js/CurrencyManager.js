let mainInput = $('#mainCurrency');
let secondaryInput = $('#secondaryCurrency');
let switchButton = $('#SwitchButton');
let candleOptions = $('#candleOptions');
let pricePer1 = 1;

let inputAmount = $('#inputAmount');
let convertedAmount = $('#convertedAmount');

initSecondarySelector();
mainInput.change(function () {
    initSecondarySelector();
    setTimeout(InitPrices, 100);
});
secondaryInput.change(function () {
    InitPrices();
});
inputAmount.change(function () {
    calculatePrice();
});

candleOptions.change(function () {
    InitPrices();
});

function initSecondarySelector() {
    let val = mainInput.val();

    $.get("Home/GetSecondaryCurrencies?mainCurrency=" + val, function (data) {
        secondaryInput.empty();
        for (var i in data.currencies) {
            secondaryInput.append(new Option(data.currencies[i], data.currencies[i]));
        }
    });
}

function InitPrices() {
    let val1 = mainInput.val();
    let val2 = secondaryInput.val();
    let conversion = val1 + '/' + val2;


    var options = {
        backgroundColor: "#f0f8ff",
        animationEnabled: true,
        title: {
            text: conversion
        },
        axisX: {
            valueFormatString: "DD MMM YYYY HH:mm:ss"
        },
        axisY: {
            title: "Price",
            prefix: ""
        },
        data: [{
            yValueFormatString: "#.###",
            xValueFormatString: "DD MMM YYYY HH:mm:ss",
            type: "spline",
            dataPoints: [
            ]
        }]
    };

    let candleOption = candleOptions.val();

    // Minute
    if (candleOption == 1) {
        options.axisX.valueFormatString = "HH:mm:ss";
        options.data[0].xValueFormatString = "HH:mm:ss";
    }
    // Hour
    else if (candleOption == 2) {
        options.axisX.valueFormatString = "DD MMM YYYY HH:mm";
        options.data[0].xValueFormatString = "DD MMM YYYY HH:mm";
    }
    // Day
    else if (candleOption == 3) {
        options.axisX.valueFormatString = "DD MMM YYYY";
        options.data[0].xValueFormatString = "DD MMM YYYY";
    }
    // Week
    else if (candleOption == 4) {
        options.axisX.valueFormatString = "DD MMM YYYY";
        options.data[0].xValueFormatString = "DD MMM YYYY";
    }

    $.get("Home/GetConversionRate?conversion=" + conversion + "&chartType=" + candleOptions.val(), function (data) {
        for (var i = 0; i < data.totalCount - 1; i++) {
            options.data[0].dataPoints.push(
                {
                    x: new Date(data.allPrices[i].timestamp), y: data.allPrices[i].currPrice
                });
        }

        pricePer1 = data.allPrices[0].currPrice
        calculatePrice();
        $("#chartContainer").CanvasJSChart(options);
    });
}

function calculatePrice() {
    inputAmount.val(inputAmount.val().replace(',', '.'));
    let amountToConvert = parseFloat(inputAmount.val());
    convertedAmount.val((amountToConvert * pricePer1).toFixed(2));
}

switchButton.on("click", function () {
    let convertedPrice = convertedAmount.val();
    inputAmount.val(convertedPrice);

    let val1 = mainInput.val();
    let val2 = secondaryInput.val();

    mainInput.val(val2);
    initSecondarySelector();

    switchButton.prop("disabled", true);

    setTimeout(function () {
        switchButton.prop("disabled", false);
    }, 2500);

    setTimeout(function () {
        secondaryInput.val(val1);
        InitPrices();
    }, 500);
});


window.onload = function () {
    setTimeout(InitPrices, 100);
}