<template>
    <div class="chart-wrapper">
      <chart :options="chartOptionsLine"></chart>
    </div>
</template>

<script>
export default {
  name: "Progress-Graph",
  data: () => ({
    chartOptionsBar: {
      xAxis: {
        data: ["Q1", "Q2", "Q3", "Q4"]
      },
      yAxis: {
        type: "value"
      },
      series: [
        {
          type: "bar",
          data: [63, 75, 24, 92]
        }
      ],
      title: {
        text: "Quarterly Sales Results",
        x: "center",
        textStyle: {
          fontSize: 24
        }
      },
      color: ["#127ac2"]
    },
    chartOptionsLine: {
      xAxis: {
        data: [
          "Jan",
          "Feb",
          "Mar",
          "Apr",
          "May",
          "Jun",
          "Jul",
          "Aug",
          "Sep",
          "Oct",
          "Nov",
          "Dec"
        ]
      },
      yAxis: {
        type: "value"
      },
      series: [
        {
          type: "line",
          data: [55, 72, 84, 48, 59, 62, 87, 75, 94, 101, 127, 118]
        }
      ],
      title: {
        text: "Fitness Progress",
        x: "center",
        textStyle: {
          fontSize: 24
        }
      },
      color: ["#127ac2"]
    }
  })
};
</script>

<style scoped>
.chart-wrapper {
  width: 100%;
  height: 700px;
}
.echarts {
  width: 100%;
  height: 100%;
}
</style>
