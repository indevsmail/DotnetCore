let temp='I am Javascript';
console.log(temp);

//OBJECTS - Reference type
let person = {
    fname:'Mosh',
    lname: 'hamedani',
    age: 30
};
console.log(person);

person.fname= 'Amit';
person['lname']= 'Rana';
console.log(person);

let first='fname';
person[first]='Ramesh';
console.log(person);

//ARRAY - Reference type
let colors=['red','blue'];
colors[2]=10;
console.log(colors);

//FUNCTIONS
function greet(firstname,lastname){
    console.log('Hello '+  firstname + ' ' + lastname);
}
greet('John','Smith');

function square(num){
    return num * num;
}
console.log(square(2));