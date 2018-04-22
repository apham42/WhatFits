function SearchResult (username, skill, distance) {
  this.username = username
  this.skill = skill
  this.distance = distance
}

SearchResult.prototype.filter = function (searchResults, skill) {
  var sortedResults = []
  sortedResults.push(searchResults)
  return sortedResults
}
