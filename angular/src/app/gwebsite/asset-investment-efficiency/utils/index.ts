import moment from 'moment';

export const addThousandSeparator = (value) => {
    return value.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1.');
}

export const getDateRangeString = (start, end) => {
    const starting = moment(new Date(start));
    const startingDate = starting.format('DD');
    const startingMonth = starting.format('MM');
    const startingYear = starting.format('YYYY');

    const ending = moment(new Date(end));
    const endingDate = ending.format('DD');
    const endingMonth = ending.format('MM');
    const endingYear = ending.format('YYYY');

    return `${ startingDate } tháng ${ startingMonth }, ${ startingYear } - ${ endingDate } tháng ${ endingMonth }, ${ endingYear }`;
}

export const getRandomValue = (min, max) => {
    return Math.floor(Math.random() * (max - min + 1) + min);
}

export const groupBy = (items, key) => items.reduce(
    (result, item) => ({
      ...result,
      [item[key]]: [
        ...(result[item[key]] || []),
        item,
      ],
    }), 
    {},
);

export const isDateBetween = (check, start, end) => {
  const dCheck = new Date(check);
  const dStart = new Date(start);
  const dEnd = new Date(end);

  return dCheck >= dStart && dCheck <= dEnd;
}

export const isValidNumber = (value) => {
  return !isNaN(value);
}

export const getRandomColor = () => {
  const o = Math.round, r = Math.random, s = 255;
  return 'rgba(' + o(r()*s) + ',' + o(r()*s) + ',' + o(r()*s) + ', 0.3)';
}