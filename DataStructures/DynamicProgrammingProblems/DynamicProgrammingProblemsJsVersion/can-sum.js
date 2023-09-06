const canSum = (targetSum, numbers, memo = {}) => {
  if (targetSum in memo) return memo[targetSum];
  if (targetSum === 0) return true;
  if (targetSum < 0) return false;
  for (let num of numbers) {
    const remainder = targetSum - num;
    if (canSum(remainder, numbers, memo) === true) {
      memo[targetSum] = true;
      return memo[targetSum];
    }
  }
  memo[targetSum] = false;
  return memo[targetSum];
};

console.log(canSum(7, [2, 3])); //true
console.log(canSum(7, [5, 4, 3, 7])); ///true
console.log(canSum(7, [2, 4])); //false
console.log(canSum(8, [2, 3, 5])); //true
console.log(canSum(300, [7, 14])); //false
