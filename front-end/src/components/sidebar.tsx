'use client'

import React from "react";
import {Accordion, AccordionItem, Checkbox, CheckboxGroup, Divider} from "@nextui-org/react";
import Link from "next/link";

export default function Sidebar(){

    return (
        
        <div className="drop-shadow-lg rounded bg-gray-200 h-full border p-2">
            <h2 className="text-center">Filter Results</h2>
              <CheckboxGroup className="p-2" disableAnimation label='Ingredients'>
                <Checkbox value="bread">Bread</Checkbox>
                <Checkbox value="meat">Meat</Checkbox>
                <Checkbox value="vegetables">Vegetables</Checkbox>
              </CheckboxGroup>
              <CheckboxGroup  className="p-2" disableAnimation label='Meal'>
                <Checkbox value="breakfast">Breakfast</Checkbox>
                <Checkbox value="lunch">Lunch</Checkbox>
                <Checkbox value="snack">Snack</Checkbox>
                <Checkbox value="dinner">Dinner</Checkbox>
              </CheckboxGroup>
              <CheckboxGroup  className="p-2"  disableAnimation label='Restrictions'>
                <Checkbox value="vegetarian">Vegetarian</Checkbox>
                <Checkbox value="vegan">Vegan</Checkbox>
                <Checkbox value="non-dairy">Non-dairy</Checkbox>
              </CheckboxGroup>

         <Divider/>

          <ul>
            {/* TODO: Create sidebar search filter component(s) */}
            
            <li className="p-2">
              Surprise me!
            </li>
            <li className="p-2">
              Articles
            </li>
            <li className="p-2">
              <Link href="/about">About</Link>
            </li>
          </ul>
        </div>
     
    )
}