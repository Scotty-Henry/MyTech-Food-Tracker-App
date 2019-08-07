<template>
  <div class="chart-wrapper">
    <chart id="chart" :options="chartOptionsLine"></chart>
  </div>
</template>

<script>

export default {
  name: "Progress-Graph",
  data: () => ({
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
      legend: {
        data: ['Current', 'Goal', 'Progress'],
        align: 'left',
        left: 10
      },
      series: [
        {
          name: "Current",
          type: "line",
          data: [55, 72, 84, 48, 59, 62, 87, 75, 94, 101, 127, 118],
        },
        {
          name: "Goal",
          type: "line",
          data: [75, 75, 75, 75, 75, 75, 75, 75, 75, 75, 75, 75]
        },
        {
          name: "Progress",
          type: "line",
          data: [29, 70, 98, 87, 42, 81, 62, 80, 77, 90, 127, 80]
        }
      ],
      title: {
        text: "Fitness Progress",
        x: "center",
        textStyle: {
          fontSize: 24
        }
      },
    }
  })
};
</script>

<style scoped>
.chart-wrapper {
  width: 100%;
  height: 500px;
}
.echarts {
  width: 100%;
  height: 100%;
}
#chart {
  height: 80vh;
}
</style>
