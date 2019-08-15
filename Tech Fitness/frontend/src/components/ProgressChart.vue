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
        name: "Date",
        data: []
      },
      yAxis: {
        name: "Total Grams",
        type: "value"
      },
      legend: {
        data: ["Carbohydrates", "Fat", "Protein"],
        x: "center",
        y: "bottom"
      },
      series: [
        // {
        //   name: "Calories",
        //   type: "line",
        //   data: []
        // },
        {
          name: "Carbohydrates",
          type: "line",
          data: []
        },
        {
          name: "Fat",
          type: "line",
          data: []
        },
        {
          name: "Protein",
          type: "line",
          data: []
        }
      ],
      title: {
        text: "Macronutrient Tracker",
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
  //  this.Datedata.forEach(element => {
  //       this.chartOptionsLine.series[0].data.push(element.suM_Cal);
  //     });
    this.Datedata.forEach(element => {
        this.chartOptionsLine.series[0].data.push(element.suM_Carb);
      });
      this.Datedata.forEach(element => {
        this.chartOptionsLine.series[1].data.push(element.suM_Fat);
      });
       this.Datedata.forEach(element => {
        this.chartOptionsLine.series[2].data.push(element.suM_Pro);
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
