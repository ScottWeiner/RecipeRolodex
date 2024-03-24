import Header from "@/components/header";
import RecipesList from "@/components/recipes-list";

export default function Home() {




  return (

    <div className="grid grid-cols-4 gap-4 p-4 h-full min-h-screen" >
      <div className="col col-span-1 bg-green-400 p-4 ">
        <div className="drop-shadow-lg rounded bg-gray-200 h-full border p-2">
          Menu goes here
        </div>
      </ div>
      <div className="col-span-3 p-4">
        <div className="text-lg bg-orange-200 grid justify-items-center mb-4">
          <h1>Favorite Recipes</h1>
        </div>
        <RecipesList />
      </div>
    </div>

  );
}
