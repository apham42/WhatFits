<template>
	<div class = "LogContainer">
		<div class = "Column">
			<li v-for="value in results" :key="value">
        <div class="Cards">
          <div id="WorkoutType">
            User Review: '{{ value.ReviewMessage }}' &nbsp;&nbsp;&nbsp;&nbsp; Recevied Rating : '{{ value.Rating }}'
							<div class="Cardio">

							</div>
							<div class="WeightLifting">

							</div>
          </div>
          <div id="dateFormat">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; '{{ value.Date_Time }}'
          </div>
        </div>
      </li>
		</div>
	</div>
</template>

<script>
</script>

<style>
div.LogContainer {
	overflow: auto;
}
div.column{
  align-items: stretch;
  display: flex;
  flex-direction: column;
  flex-wrap: nowrap;
  overflow-x: auto;
  overflow-y: hidden;
}
div.card {
  max-height: 33.333%;
  padding: .75rem;
  margin-bottom: 2rem;
  border: 0;
  flex-basis: 33.333%;
  flex-grow: 0;
  flex-shrink: 0;
}
</style>