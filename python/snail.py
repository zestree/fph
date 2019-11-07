def snail(array):
    myList = []
    n = len(array)
    i = 0
    #left, right, up, down
    bounds = [0,n-1, 0, n-1]
    #right, down, left, up
    direction = [1,0,0,0]
    inc = 0
    
    if n ==1:return array[0]
    
    while i != n*n:
        x = direction.index(1)
        if x == 0:
            myList.append(array[bounds[2]][inc])
            if inc == bounds[1]:
                direction[0] = 0
                direction[1] = 1
                bounds[2] +=1
                inc = bounds[2]
            else: inc+=1
        if x == 1:
            myList.append(array[inc][bounds[1]])
            if inc == bounds[3]:
                direction[1] = 0
                direction[2] = 1
                bounds[1] -= 1
                inc = bounds[1]
            else: inc += 1
        if x == 2:
            myList.append(array[bounds[3]][inc])
            if inc == bounds[0]:
                direction[2] = 0
                direction[3] = 1
                bounds[3] -= 1
                inc = bounds[3]
            else: inc -= 1
        if x == 3:
            myList.append(array[inc][bounds[0]])
            if inc == bounds[2]:
                direction[3] = 0
                direction[0] = 1
                bounds[0] += 1
                inc = bounds[0]
            else: inc -= 1
        i+=1
    return(myList)