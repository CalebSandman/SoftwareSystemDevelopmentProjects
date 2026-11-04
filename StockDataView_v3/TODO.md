/*
 * TODO:Incomporate trendlines using annotations
 *      Create rectangle annotations covering the rectangle made by each trendline
 *      Peaks and valleys are defined as the high/low values being higher or lower than the candlesticks to either side. A candlestick can be both a peak and a valley
 *          (Use a new class derived from objCandlestick, peakValley finder)?
 *      Trendlines point from peaks to a low or valley to a high. Trends are valid if no candlesticks in the rectangle pierce it
 *          IDEA: trends go from peaks to valleys and vice versa only if there is not a higher/lower peak inbetween
 *          
 *      
 *      
 *      Start with a form that lets you select multiple files
 *      Opens all files in their own form with chart
 *          Each form has date selectors and update button. NO open file button
 *      Mark peaks and valleys
 *      Change candlestick colors to red and green for down and up days
 *      
 *      "internal class" to "public Static class" (not doing
 *      
 *      
 *      CHANGE BACK TO TWO CHART AREAS
 *      
 *      Rubberbanding for the trend rectangles. Verify that the trend is valid for the rectangle to persist
*		Mark when O, H, L, C are within 1% of fibbionachi lines
 */