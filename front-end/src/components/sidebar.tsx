'use client'

export default function Sidebar(){

    return (
        
        <div className="drop-shadow-lg rounded bg-gray-200 h-full border p-2">
          Filter goes here
          <ul>
            {/* TODO: Create sidebar search filter component(s) */}
            <li>By Ingredients:</li>
            <li>By Meal Type</li>
            <li>Restictions</li>
            <li>Surprise me!</li>
            <li>Articles?</li>
            <li>About</li>
            <li>.....</li>
          </ul>
        </div>
     
    )
}