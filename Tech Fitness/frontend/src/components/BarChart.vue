
<template>
  <div class="chart-wrapper">
    <chart id="chart" :options="chartOptionsBar"></chart>
  </div>
</template>

<script>
export default {
  name: 'Bar-Chart',
  props: {
      NutritionOnDay: Object,
      goalCarb: Object,
      goalFat: Object,
      goalPro: Object,
  },
  data: () => ({
    chartOptionsBar: {
  xAxis: {
    data: ['Carb', 'Fat', 'Pro']
  },
  yAxis: {
    name: "Grams",
    type: 'value'
  },
  series: [
    {
      type: 'bar',
      data: []
    },
     {
          type: "bar",
          data: []
        },
  ],
  title: {
    text: 'Today',
     x: 'center',
    textStyle: {
      fontSize: 12
    }
  }
}

  }),
   watch: {
    NutritionOnDay: function() {
        this.chartOptionsBar.series[0].data.push(this.NutritionOnDay.carb);
         this.chartOptionsBar.series[0].data.push(this.NutritionOnDay.fat);
          this.chartOptionsBar.series[0].data.push(this.NutritionOnDay.pro);
      },
      goalCarb: function() {
        this.chartOptionsBar.series[1].data.push(this.goalCarb.carbGrams); 
      },
      goalFat: function() {
        this.chartOptionsBar.series[1].data.push(this.goalFat.fatGrams); 
      },
      goalPro: function() {
        this.chartOptionsBar.series[1].data.push(this.goalPro.proGrams); 
      },
    
    }
  }

</script>

<style scoped>
.chart-wrapper {
  width: 80%;
  height: 100%;
}
.echarts {
  width: 80%;
  height: 80%;
}
#chart {
  height: 40vh;
  width: 20.5vw;
  -webkit-tap-highlight-color: transparent;
}
</style>

