// -------------------------------------------------------------------------------------------------------------------------------------------
// Dashboard 1 : Chart Init Js
// -------------------------------------------------------------------------------------------------------------------------------------------
$(function () {
  "use strict";
  // -----------------------------------------------------------------------
  // Sales overview
  // -----------------------------------------------------------------------

  var options_Sales_Overview = {
    series: [
      {
        name: "Pixel ",
        data: [9, 5, 3, 7, 5, 10, 3],
      },
      {
        name: "Ample ",
        data: [6, 3, 9, 5, 4, 6, 4],
      },
    ],
    chart: {
      fontFamily: "inherit",
      type: "bar",
      height: 330,
      foreColor: "#adb0bb",
      offsetY: 10,
      toolbar: {
        show: false,
      },
    },
    grid: {
      show: true,
      strokeDashArray: 3,
      borderColor: "rgba(0,0,0,.1)",
    },
    colors: ["var(--bs-primary)", "var(--bs-secondary)"],
    plotOptions: {
      bar: {
        horizontal: false,
        columnWidth: "30%",
        endingShape: "flat",
        borderRadius:4,
      },
    },
    dataLabels: {
      enabled: false,
    },
    stroke: {
      show: true,
      width: 5,
      colors: ["transparent"],
    },
    xaxis: {
      type: "category",
      categories: ["Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"],
      axisTicks: {
        show: false,
      },
      axisBorder: {
        show: false,
      },
      labels: {
        style: {
          colors: "#a1aab2",
        },
      },
    },
    yaxis: {
      labels: {
        style: {
          colors: "#a1aab2",
        },
      },
    },
    fill: {
      opacity: 1,
      colors: ["var(--bs-primary)", "var(--bs-secondary)"],
    },
    tooltip: {
      theme: "dark",
    },
    legend: {
      show: false,
    },
    responsive: [
      {
        breakpoint: 767,
        options: {
          stroke: {
            show: false,
            width: 5,
            colors: ["transparent"],
          },
        },
      },
    ],
  };

  var chart_column_basic = new ApexCharts(
    document.querySelector("#sales-overview"),
    options_Sales_Overview
  );
  chart_column_basic.render();

  // -----------------------------------------------------------------------
  // Newsletter
  // -----------------------------------------------------------------------

  var Newsletter_Campaign = {
    series: [
      { name: "Inbound Calls", data: [65, 80, 80, 60, 60, 45, 45, 80, 80, 70, 70, 90, 90, 80, 80, 80, 60, 60, 50] },
      { name: "Outbound Calls", data: [90, 110, 110, 95, 95, 85, 85, 95, 95, 115, 115, 100, 100, 115, 115, 95, 95, 85, 85] },
    ],
    chart: { fontFamily: "inherit", type: "area", height: 300, toolbar: { show: !1 } },
    plotOptions: {},
    legend: { show: !1 },
    dataLabels: { enabled: !1 },
    fill: { type: "solid",  opacity: 0.07,  colors: ["#1B84FF", "#43CED7"] },
    stroke: { curve: "smooth", show: !0, width: 2, colors: ["var(--bs-primary)", "var(--bs-secondary)"] },
    xaxis: {
      categories: ["", "8 AM", "81 AM", "9 AM", "10 AM", "11 AM", "12 PM", "13 PM", "14 PM", "15 PM", "16 PM", "17 PM", "18 PM", "18:20 PM", "18:20 PM", "19 PM", "20 PM", "21 PM", ""],
      axisBorder: { show: !1 },
      axisTicks: { show: !1 },
      tickAmount: 6,
      labels: { rotate: 0, rotateAlways: !0, style: { fontSize: "12px", colors: "#a1aab2" } },
      crosshairs: { position: "front", stroke: { color: ["var(--bs-primary)", "var(--bs-secondary)"], width: 1, dashArray: 3 } },

    },
    yaxis: { max: 120, min: 30, tickAmount: 6, labels: { style: { fontSize: "12px", colors: "#a1aab2" } } },
    states: { normal: { filter: { type: "none", value: 0 } }, hover: { filter: { type: "none", value: 0 } }, active: { allowMultipleDataPointsSelection: !1, filter: { type: "none", value: 0 } } },
    tooltip: {
        theme: "dark",
    },
    colors: ["var(--bs-primary)", "var(--bs-secondary)"],
    grid: { borderColor: "var(--bs-border-color)", strokeDashArray: 4, yaxis: { lines: { show: !0 } } },
    markers: { strokeColor: ["var(--bs-primary)", "var(--bs-secondary)"], strokeWidth: 3 },
  };

  var chart_area_spline = new ApexCharts(
    document.querySelector("#newsletter-campaign"),
    Newsletter_Campaign
  );
  chart_area_spline.render();


  // -----------------------------------------------------------------------
  // Our visitor
  // -----------------------------------------------------------------------

  var option_Our_Visitors = {
    series: [50, 40, 30, 10],
    labels: ["Mobile", "Tablet", "Other", "Desktop"],
    chart: {
      type: "donut",
      height: 250,
      fontFamily: "inherit",
    },
    dataLabels: {
      enabled: false,
    },
    stroke: {
      width: 0,
    },
    plotOptions: {
      pie: {
        expandOnClick: true,
        donut: {
          size: "83",
          labels: {
            show: true,
            name: {
              show: true,
              offsetY: 7,
            },
            value: {
              show: false,
            },
            total: {
              show: true,
              color: "#a1aab2",
              fontSize: "13px",
              label: "Our Visitor",
            },
          },
        },
      },
    },
    colors: ["var(--bs-primary)", "var(--bs-secondary)", "#eceff180", "var(--bs-purple)"],
    tooltip: {
      show: true,
      fillSeriesColor: false,
    },
    legend: {
      show: false,
    },
    responsive: [
      {
        breakpoint: 1025,
        options: {
          chart: {
            height: 270,
          },
        },
      },
      {
        breakpoint: 426,
        options: {
          chart: {
            height: 250,
          },
        },
      },
    ],
  };

  var chart_pie_donut = new ApexCharts(
    document.querySelector("#our-visitors"),
    option_Our_Visitors
  );
  chart_pie_donut.render();

  // -----------------------------------------------------------------------
  // Badnwidth usage
  // -----------------------------------------------------------------------

  var option_Bandwidth_usage = {
    series: [
      {
        name: "",
        labels: ["0", "4", "8", "12", "16", "20", "24", "30"],
        data: [0,8,12,10,6,8,15,23],
      },
    ],
    chart: {
      height: 50,
      type: "line",
      foreColor: "#adb0bb",
      toolbar: {
        show: false,
      },
      sparkline: {
        enabled: true,
      },
    },
    colors: ["#fff"],
    fill: {
      type: "solid",
      opacity: 1,
      colors: ["#fff"],
    },
    grid: {
      show: false,
    },
    stroke: {
      curve: "smooth",
      lineCap: "square",
      colors: ["#fff"],
      width: 2,
    },
    markers: {
      size: 0,
      colors: ["#fff"],
      strokeColors: "transparent",
      shape: "square",
      hover: {
        size: 7,
      },
    },
    xaxis: {
      axisBorder: {
        show: false,
      },
      axisTicks: {
        show: false,
      },
      labels: {
        show: false,
      },
    },
    yaxis: {
      labels: {
        show: false,
      },
    },
    tooltip: {
      theme: "dark",
      style: {
        fontSize: "10px",
        fontFamily: "inherit",
      },
      x: {
        show: false,
      },
      y: {
        formatter: undefined,
      },
      marker: {
        show: true,
      },
      followCursor: true,
    },
  };

  var chart_line_basic = new ApexCharts(
    document.querySelector("#bandwidth-usage"),
    option_Bandwidth_usage
  );
  chart_line_basic.render();

  // -----------------------------------------------------------------------
  // Download count
  // -----------------------------------------------------------------------

  var option_Download_count = {
    series: [
      {
        name: "",
        data: [4, 5, 2, 10, 9, 12, 4, 9, 4, 5, 3, 10],
      },
    ],
    chart: {
      type: "bar",
      fontFamily: "inherit",
      height: 50,
      foreColor: "#adb0bb",
      toolbar: {
        show: false,
      },
      sparkline: {
        enabled: true,
      },
    },
    colors: ["rgba(255, 255, 255, 0.7)"],
    grid: {
      show: false,
    },
    plotOptions: {
      bar: {
        horizontal: false,
        startingShape: "flat",
        endingShape: "flat",
        columnWidth: "60%",
        barHeight: "100%",
        borderRadius: 2,
      },
    },
    dataLabels: {
      enabled: false,
    },
    stroke: {
      show: true,
      width: 4,
      colors: ["transparent"],
    },
    xaxis: {
      axisBorder: {
        show: false,
      },
      axisTicks: {
        show: false,
      },
      labels: {
        show: false,
      },
    },
    yaxis: {
      labels: {
        show: false,
      },
    },
    axisBorder: {
      show: false,
    },
    fill: {
      opacity: 1,
    },
    tooltip: {
      theme: "dark",
      style: {
        fontSize: "12px",
        fontFamily: "inherit",
      },
      x: {
        show: false,
      },
      y: {
        formatter: undefined,
      },
    },
  };

  var chart_column_basic = new ApexCharts(
    document.querySelector("#download-count"),
    option_Download_count
  );
  chart_column_basic.render();
});
