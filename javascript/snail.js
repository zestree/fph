snail = function(array) {
    const output = [];
    let i = 0;
    let direction = 1; // 1 - increasing; -1 - decreasing
  
    while (array.length && array[i]) {
      if (array[i].length === 0 && i === 0) { // empty first row after clearing - remove it and reverse direction
        array.shift();
  
        if (direction === -1) {
          direction = 1;
        }
      } else if (array[i].length === 0 && i === array.length - 1) { // empty last row after clearing - remove it, reverse direction and go back to previous row
        array.pop();
  
        if (direction === 1) {
          direction = -1;
        }
  
        i += direction;
      } else if (i === 0) { // first row - retrieve all items, reverse direction and go to next row
        output.push(...array[i]);
        array[i] = [];
  
        if (direction === -1) {
          direction = 1;
        }
  
        i += direction;
      } else if (array.length-1 === i) { // last row - retrieve all items reversed, reverse direction and go to previous row
        output.push(...array[i].reverse());
        array[i] = [];
  
        if (direction === 1) {
          direction = -1;
        }
  
        i += direction;
      } else { // middle rows - take last or first item, depending on direction
        if (direction === 1) {
          output.push(array[i].pop());
        } else {
          output.push(array[i].shift());
        }
  
        i += direction;
      }
    }
    
    return output;
  }