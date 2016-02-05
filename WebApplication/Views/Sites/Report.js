function makeVisitorsChart(months) {
    document.getElementById('visitorsChart').innerHTML = 'Data not available yet';
    var visitorsChartData = new google.visualization.DataTable();
    visitorsChartData.addColumn('date', 'Month');
    visitorsChartData.addColumn('number', 'Total Visitors');
    visitorsChartData.addColumn('number', 'Projected');
    visitorsChartData.addColumn('number', 'Upper Projected');
    for (var i = 0; i < months.length; i++) {
        visitorsChartData.addRow([
            new Date(months[i].MonthTime),
            months[i].VisitorsTotal,
            months[i].VisitorsTotalModel,
            months[i].VisitorsTotalModelUpper
        ]);
    }
    // Instantiate and draw our chart, passing in some options
    var incomeChart = new google.visualization.LineChart(document.getElementById('visitorsChart'));
    incomeChart.draw(visitorsChartData,
    {
        width: 700,
        height: 300,
        chartArea: { width: '50%' },
        hAxis: { format: 'MMM-yyyy' },
        vAxis: { title: "Visitor Numbers" }
    });
}
function makeAdmissionIncomeChart(months) {
    document.getElementById('incomeChart').innerHTML = 'Data not available yet';
    // Prepare the data table
    var incomeChartData = new google.visualization.DataTable();
    incomeChartData.addColumn('date', 'Month');
    incomeChartData.addColumn('number', 'Admissions Inome');
    incomeChartData.addColumn('number', 'Projected');
    incomeChartData.addColumn('number', 'Upper Projected');
    for (var i = 0; i < months.length; i++) {
        incomeChartData.addRow([
            new Date(months[i].MonthTime),
            months[i].IncomeAdmissions,
            months[i].IncomeAdmissionsModel,
            months[i].IncomeAdmissionsModelUpper
        ]);
    }
    // Instantiate and draw our chart, passing in some options
    var incomeChart = new google.visualization.LineChart(document.getElementById('incomeChart'));
    incomeChart.draw(incomeChartData,
    {
        width: 700,
        height: 300,
        chartArea: { width: '50%' },
        hAxis: { format: 'MMM-yyyy' },
        vAxis: { title: "Admissions Income", format: '£#,###' }
    });
}

function makeRetailIncomePerVisitorChart(months) {
    document.getElementById('retailIncomePerVisitorChart').innerHTML = 'Data not available yet';
    // Prepare the data table
    var retailIncomePerVisitorChartData = new google.visualization.DataTable();
    retailIncomePerVisitorChartData.addColumn('date', 'Month');
    retailIncomePerVisitorChartData.addColumn('number', 'Retail Income Per Visitor');
    retailIncomePerVisitorChartData.addColumn('number', 'Projected');
    retailIncomePerVisitorChartData.addColumn('number', 'Upper Projected');
    try {
        for (var i = 0; i < months.length; i++) {
            retailIncomePerVisitorChartData.addRow([
                new Date(months[i].MonthTime),
                months[i].RetailIncomePerVisitor,
                months[i].RetailIncomePerVisitorModel,
                months[i].RetailIncomePerVisitorModelUpper
            ]);
        }
        // Instantiate and draw our chart, passing in some options
        var incomePerVisitorChart = new google.visualization.LineChart(document.getElementById('retailIncomePerVisitorChart'));
        incomePerVisitorChart.draw(retailIncomePerVisitorChartData,
        {
            width: 700,
            height: 300,
            chartArea: { width: '50%' },
            hAxis: { format: 'MMM-yyyy' },
            vAxis: { title: "Retail Income Per Visitor", format: '£0.00' }
        });
    } catch (err) {
        document.getElementById('retailIncomePerVisitorChart').innerHTML = 'Complete data not available for graph</br>' +
            '<i>' + err.message + '</i>';
    }
}

function makeRefreshmentIncomePerVisitorChart(months) {
    document.getElementById('refreshmentIncomePerVisitorChart').innerHTML = 'Data not available yet';
    // Prepare the data table
    var refreshmentIncomePerVisitorChartData = new google.visualization.DataTable();
    refreshmentIncomePerVisitorChartData.addColumn('date', 'Month');
    refreshmentIncomePerVisitorChartData.addColumn('number', 'Refreshment Income Per Visitor');
    refreshmentIncomePerVisitorChartData.addColumn('number', 'Projected');
    refreshmentIncomePerVisitorChartData.addColumn('number', 'Upper Projected');
    try {
        for (var i = 0; i < months.length; i++) {
            refreshmentIncomePerVisitorChartData.addRow([
                new Date(months[i].MonthTime),
                months[i].RefreshmentIncomePerVisitor,
                months[i].RefreshmentIncomePerVisitorModel,
                months[i].RefreshmentIncomePerVisitorModelUpper
            ]);
        }
        // Instantiate and draw our chart, passing in some options
        var incomePerVisitorChart = new google.visualization.LineChart(document.getElementById('refreshmentIncomePerVisitorChart'));
        incomePerVisitorChart.draw(refreshmentIncomePerVisitorChartData,
        {
            width: 700,
            height: 300,
            chartArea: { width: '50%' },
            hAxis: { format: 'MMM-yyyy' },
            vAxis: { title: "Refreshment Income Per Visitor", format: '£0.00' }
        });
    } catch (err) {
        document.getElementById('refreshmentIncomePerVisitorChart').innerHTML = 'Complete data not available for graph</br>' +
            '<i>' + err.message + '</i>';
    }
}

function addRawData(siteData) {
    var siteData = JSON.stringify(siteData, undefined, 2);
    document.getElementById('rawData').innerHTML = siteData;
}

function round(number) {
    return Math.round(number * 100) / 100;
}