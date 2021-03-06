module Shield

using ..Ahorn, Maple
@mapdef Entity "DJMapHelper/shield" Sheild(x::Integer, y::Integer)

const placements = Ahorn.PlacementDict(
    "Sheild (DJMapHelper)" => Ahorn.EntityPlacement(
        Sheild
    )
)

function Ahorn.selection(entity::Sheild)
    x, y = Ahorn.position(entity)
    
    return Ahorn.Rectangle(x - 12, y - 12, 24, 24)
end

function Ahorn.render(ctx::Ahorn.Cairo.CairoContext, entity::Sheild, room::Maple.Room)
    Ahorn.Cairo.save(ctx)

    Ahorn.set_antialias(ctx, 1)
    Ahorn.set_line_width(ctx, 1);

    Ahorn.drawCircle(ctx, 0, 0, 12, (1.0, 1.0, 1.0, 1.0))

    Ahorn.Cairo.restore(ctx)

end

end