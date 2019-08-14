<template>
  <div class="chart-wrapper">
    <chart id="chart" :options="chartOptionsLine"></chart>
  </div>
</template>

<script>
export default {
  name: "Progress-Graph",
  props: {
    Datedata: Array,
  },
  data: () => ({
    chartOptionsLine: {
      xAxis: {
        // this will be my array of dates
        data: []
      },
      yAxis: {
        type: "value"
      },
      legend: {
        data: ["Current", "Goal", "Progress"],
        x: "center",
        y: "bottom"
      },
      series: [
        {
          name: "Current",
          type: "line",
          data: [55, 72, 84, 48, 59, 62, 87, 75, 94, 101, 127, 118]
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
      }
    }
  }),
  watch: {
    Datedata: function() {
      this.Datedata.forEach(element => {
        this.chartOptionsLine.xAxis.data.push(element.date);
      });
   
    }
  }
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
  width: auto;
  -webkit-tap-highlight-color: transparent;
}
</style>
